using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        //try
        //{
            BookReviewDbEntities2 db = new BookReviewDbEntities2();
            RandomSeed rs = new RandomSeed();
            PasswordHash ph = new PasswordHash();
            int seed = rs.GetSeed();
            Byte[] hashed = ph.HashIt(txtPassword.Text, seed.ToString());
            Reviewer rev = new Reviewer();
            rev.ReviewerFirstName = txtFirstName.Text;
            rev.ReviewerLastName = txtLastName.Text;
            rev.ReviewerEmail = txtEmail.Text;
            rev.ReviewerUserName = txtUserName.Text;
            rev.ReviewerDateEntered = DateTime.Now;
            rev.ReviewPlainPassword = txtPassword.Text;
            rev.ReviewerKeyCode = seed;
            rev.ReviewerHashedPass = hashed;
            db.Reviewers.Add(rev);
            db.SaveChanges();
            lblErrorSuccess.Text = "Reviewer Saved!";
        /*}
        catch(Exception ex)
        {
            lblErrorSuccess.Text = ex.Message;
        }*/
    }
}