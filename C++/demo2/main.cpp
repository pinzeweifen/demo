#include <QApplication>
#include "myscene.h"
#include "myview.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

    const int width = 800;
    const int height = 600;


    MyScene scene;
    scene.setSceneRect(-width*0.5,-height*0.5,width,height);

    MyView view(&scene);
    view.resize(width+5,height+5);
    view.show();


    return a.exec();
}
