using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// 

/// Summary description for LoginClass
/// 

public class LoginClass
{
    string password;
    string userName;
    //int personkey = 0;
    //Byte[] hashed;
    CommunityAssistEntities ce = new CommunityAssistEntities();

    public LoginClass(string pass, string user)
    {
        password = pass;
        userName = user;
    }

    public int ValidateLogin()
    {
        //personkey to return initally 0
        int pk = 0;

        //LINQ to extract personkey, passcode and hash from database
        var log = from r in ce.People
                  where r.PersonUsername == userName
                  && r.PersonPlainPassword == password
                  select new { r.PersonKey, r.Personpasskey, r.PersonUserPassword };
        //variables to store results from database
        int pCode = 0;
        Byte[] pWord = null;
        int personKey = 0;

        //loop throug results and assign values from var log
        //to our variables
        foreach (var p in log)
        {
            personKey = (int)p.PersonKey;
            pCode = (int)p.Personpasskey;
            pWord = (Byte[])p.PersonUserPassword;
        }
        //initial the PassWordHash
        PasswordHash ph = new PasswordHash();
        //send password and passcode to be hashed
        Byte[] newHash = ph.HashIt(password, pCode.ToString());


        if (pWord.SequenceEqual(newHash))
        {
            pk = personKey;
        }
        return pk;
    }

}