using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            if (taskManager.Add(new StrikeKillTask(0,new Award(),
                new EqOperation(1,1),new EqOperation(1,1),new EqOperation(1,1))))
            {

            }


            if(new EqOperation(
                1,new NotEqOperation(
                    2,new OrOperation(
                        new EqOperation(3,4), new EqOperation(5, 6)))).IsTrue())
            {
                //code
            }
        }
    }
}
