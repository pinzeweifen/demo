#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class QTcpSocket;
class QLabel;

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void read();

    void on_login_clicked();

    void on_register_2_clicked();

private:
    Ui::MainWindow *ui;
    QTcpSocket *m_TcpSocket;
    QLabel *m_Laebl;
};

#endif // MAINWINDOW_H
