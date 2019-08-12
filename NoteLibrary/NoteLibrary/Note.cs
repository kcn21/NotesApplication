using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NoteLibrary
{
    [DataContract]
    public class Note
    {
        private int Id;
        private string Title;
        private string Content;
        [DataMember]
        public int NoteId
        {
            get { return Id; }
            set { Id = value; }
        }

        [DataMember]
        public string NoteTitle
        {
            get { return Title; }
            set { Title = value; }
        }

        [DataMember]
        public string NoteContent
        {
            get { return Content; }
            set { Content = value; }
        }
    }
}
