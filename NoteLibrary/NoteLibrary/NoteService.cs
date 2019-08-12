using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NoteLibrary
{
    public class NoteService : INoteService
    {
        public DataSet GetNotes()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM notes",
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=note;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataSet ds = new DataSet();
            da.Fill(ds, "notes");
            return ds;
        }
        public Note Getnote(int id)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=note;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM notes WHERE noteid = @id";
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Note nt = new Note();
            while(reader.Read())
            {
                nt.NoteId = reader.GetInt32(0);
                nt.NoteTitle = reader.GetString(1);
                nt.NoteContent = reader.GetString(2);
            }
            reader.Close();
            cnn.Close();
            return nt;
        }
        public void AddNote(int id,string title,string content)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=note;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "INSERT into notes(noteid,notetitle,notecontent) values(@id,@title,@content)";
            SqlParameter p1 = new SqlParameter("@id", id);
            SqlParameter p2 = new SqlParameter("@title", title);
            SqlParameter p3 = new SqlParameter("@content", content);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cnn.Open();
            cmd.ExecuteNonQuery();
            /*Note nt = new Note();
            nt.NoteId = id;
            nt.NoteTitle = title;
            nt.NoteContent= content;*/
            GetNotes();
            //return null;
        }
        public void UpdateNote(int id,string title,string content)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=note;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "UPDATE note set noteid=@id,notetitle=@title,notecontent=@content";
            SqlParameter p1 = new SqlParameter("@id", id);
            SqlParameter p2 = new SqlParameter("@title", title);
            SqlParameter p3 = new SqlParameter("@content", content);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cnn.Open();
            cmd.ExecuteNonQuery();
            GetNotes();
            //return null;
        }
        public void DeleteNote(int id)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=note;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "DELETE FROM note where noteid=@id";
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
            cnn.Open();
            cmd.ExecuteNonQuery();
            GetNotes();
            //return null;
        }
    }
}
