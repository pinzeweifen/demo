#include "loginserver.h"
#include "ui_loginserver.h"
#include <QTcpServer>
#include <QTcpSocket>
#include <QDebug>
#include <database.h>

LoginServer::LoginServer(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::LoginServer)
{
    ui->setupUi(this);
//! 链接数据库
    m_Db = new Database();
    connect(m_Db,&Database::errorMessage,this,[]( QString message){
        qDebug()<< message;
    });
    if(m_Db->open()) return;

//! 监听端口
    m_TcpServer= new QTcpServer(this);

    if(!m_TcpServer->listen(QHostAddress("127.0.0.1"),8899)){
        qDebug()<< "无法监听端口";
        return;
    }
    connect(m_TcpServer ,&QTcpServer::newConnection, this, &LoginServer::newConnection);
}

LoginServer::~LoginServer()
{
    delete ui;
    delete m_TcpServer;
    delete m_Db;
}

void LoginServer::newConnection()
{
    auto client = m_TcpServer->nextPendingConnection();
//! 这里应该判断一下用户是否已存在
    m_ClientList.append(client);
    connect(client, &QTcpSocket::readyRead, this, &LoginServer::readyRead);
//! 这里应该启动一个定时器 检测心跳
}

void LoginServer::readyRead()
{
    QTcpSocket* client = (QTcpSocket*)sender();
    auto data = client->readAll();
    char sign = data[0];
    QString user = data.remove(0,1);
    char *message;
    if(sign == 'l'){
        message = new char[11];
        long uid = m_Db->getUId((QString)user);
        itoa(uid,message,10);
    }
    else
    {
        message = new char[6];
        if(m_Db->insertUser((QString)user))
              strcpy(message,"false");
        else
            strcpy(message,"true");
    }
    client->write(message,strlen(message));
    delete []message;
}
