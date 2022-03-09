using  System;
namespace Flightbookingapi{
    public class AccountNotFound :ApplicationException{
        public AccountNotFound(string msg): base(msg){

        }
    }
}