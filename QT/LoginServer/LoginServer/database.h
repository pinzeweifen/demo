#ifndef DATABASE_H
#define DATABASE_H

#include <QObject>

class QSqlQuery;

class Database:public QObject
{
    Q_OBJECT
public:
    Database(QObject *parent=nullptr);
    bool open();
    bool insertUser(const QString &&user);
    int getUId(const QString && user);

signals:
    void errorMessage( QString message);

private:
    QSqlQuery *m_Query;
};

#endif // DATABASE_H
