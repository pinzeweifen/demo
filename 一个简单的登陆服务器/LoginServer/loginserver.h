#ifndef LOGINSERVER_H
#define LOGINSERVER_H

#include <QMainWindow>

namespace Ui {
class LoginServer;
}

class QTcpServer;
class QTcpSocket;
class Database;

class LoginServer : public QMainWindow
{
    Q_OBJECT

public:
    explicit LoginServer(QWidget *parent = 0);
    ~LoginServer();

private slots:
    void newConnection();
    void readyRead();
private:
    Ui::LoginServer *ui;
    QTcpServer *m_TcpServer;
    QList<QTcpSocket*> m_ClientList;
    Database *m_Db;
};

#endif // LOGINSERVER_H
