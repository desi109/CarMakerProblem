using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarMakerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread carMaker = new Thread(CarMakerProblem.CarMaker);
            carMaker.Start();

            Thread client1 = new Thread(CarMakerProblem.Client);
            client1.Start(1);

            Thread client2 = new Thread(CarMakerProblem.Client);
            client2.Start(2);

            Thread client3 = new Thread(CarMakerProblem.Client);
            client3.Start(3);
        }
    }
}
