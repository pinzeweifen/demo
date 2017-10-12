#include "database.h"
#include <QSqlDatabase>
#include <QSqlQuery>
#include <QVariant>

Database::Database(QObject *parent):QObject(parent){}

bool Database::open()
{
    auto list = QSqlDatabase::drivers();
    if(-1==list.indexOf(QRegExp("QMYSQL"))){
        emit errorMessage("没有MYSQL驱动");
        return true;
    }

    QSqlDatabase db = QSqlDatabase::addDatabase("QMYSQL");
    m_Query = new QSqlQuery(db);
    db.setDatabaseName("game");
    db.setHostName("localhost");
    db.setUserName("root");
    db.setPassword("root");

    if(!db.open()){
        db.setDatabaseName("mysql");
        if(!db.open()){
            emit errorMessage("无法打开数据库");
            return true;
        }
        if(!m_Query->exec("create database game")){
            emit errorMessage("无法创建数据库");
            return true;
        }
    }

    m_Query->exec("use game");
    m_Query->exec("show tables");
    bool table = true;
    while(m_Query->next()){
        if(m_Query->value(0).toString() == "user"){
            table = false;
            break;
        }
    }
    if(table){
        emit errorMessage("表还没创建呢");
        if(!m_Query->exec("create table user("
                          "uid INT NOT NULL AUTO_INCREMENT,"
                          "user VARCHAR(100) NOT NULL,PRIMARY KEY(uid))"))
        {
            emit errorMessage("无法创建表");
            return true;
        }
    }

    return false;
}

bool Database::insertUser(const QString &&user)
{
    if(-1 != getUId((QString)user)){
        emit errorMessage("已经存在该用户");
        return true;
    }

    if(!m_Query->exec(QString("insert into user(user) values('%1')").arg(user))){
        emit errorMessage("创建用户失败");
        return true;
    }

    return false;
}

int Database::getUId(const QString &&user)
{
    m_Query->exec(QString("select uid from user where user='%1'").arg(user));
    if(m_Query->size() == 0){
        return -1;
    }

    m_Query->next();
    emit errorMessage(m_Query->value(0).toString());
    return m_Query->value(0).toInt();
}











