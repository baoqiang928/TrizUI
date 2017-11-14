using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class UserInfo
    {
       int? id;
                                    public int? ID
                                    {
                                        get { return id; }
                                        set { id = value; }
                                    }
                                    private string name;
                                    public string Name
                                    {
                                        get { return name; }
                                        set { name = value; }
                                    }
                                    private string company;
                                    public string Company
                                    {
                                        get { return company; }
                                        set { company = value; }
                                    }
                                    private string mobile;
                                    public string Mobile
                                    {
                                        get { return mobile; }
                                        set { mobile = value; }
                                    }
                                    private string email;
                                    public string Email
                                    {
                                        get { return email; }
                                        set { email = value; }
                                    }
                                    private string account;
                                    public string Account
                                    {
                                        get { return account; }
                                        set { account = value; }
                                    }
                                    private string password;
                                    public string Password
                                    {
                                        get { return password; }
                                        set { password = value; }
                                    }
                                    private string remark;
                                    public string Remark
                                    {
                                        get { return remark; }
                                        set { remark = value; }
                                    }
                                    private DateTime? createDateTime;

                                    public DateTime? CreateDateTime
                                    {
                                        get { return createDateTime; }
                                        set { createDateTime = value; }
                                    }
                                    
    }
}


