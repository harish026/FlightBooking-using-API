using  System;
namespace Flightbookingapi{
    public class InsufficientPassangers :ApplicationException{
        public InsufficientPassangers(string msg): base(msg){

        }
    }
}