#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QTcpSocket>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    m_Laebl = new QLabel(this);
    ui->statusBar->addWidget(m_Laebl);
    m_Laebl->setTextFormat(Qt::RichText);

    m_TcpSocket = new QTcpSocket(this);
    m_TcpSocket->abort();
    m_TcpSocket->connectToHost("127.0.0.1",8899);

    if(!m_TcpSocket->waitForConnected(1000)){
        qDebug()<<"链接超时";
        return;
    }
    connect(m_TcpSocket,&QTcpSocket::readyRead,this,&MainWindow::read);
}

MainWindow::~MainWindow()
{
    delete ui;
    delete m_TcpSocket;
    delete m_Laebl;
}

void MainWindow::read()
{
    auto data = m_TcpSocket->readAll();
    QAction *action = new QAction();
    action->setText("123");
    if(data == "true"){
        m_Laebl->setText("<font color=green>注册成功</font>");
    }else if(data == "false") {
        m_Laebl->setText("<font color=red>注册失败</font>");
    } else if(data == "-1") {
        m_Laebl->setText("<font color=red>登陆失败</font>");
    }else {
        m_Laebl->setText("<font color=green>登陆成功</font>");
    }
}

void MainWindow::on_login_clicked()
{
    QString data = "l"+ui->user->text();
    data+= ui->passwork->text();
    const char* str = data.toStdString().c_str();
    m_TcpSocket->write(str,strlen(str));
}

void MainWindow::on_register_2_clicked()
{
    QString data = "r"+ui->user->text();
    data+= ui->passwork->text();
    const char* str = data.toStdString().c_str();
    m_TcpSocket->write(str,strlen(str));
}
