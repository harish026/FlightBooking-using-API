using  System;
namespace Flightbookingapi{
    public class NegativeValueException :ApplicationException{
        public NegativeValueException(string msg): base(msg){

        }
    }
}