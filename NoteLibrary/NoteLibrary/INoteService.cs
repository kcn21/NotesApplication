using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace NoteLibrary
{
    [ServiceContract]
    public interface INoteService
    {
        [OperationContract]
        DataSet GetNotes();

        [OperationContract]
        Note Getnote(int id);

        [OperationContract]
        void AddNote(int id,string title,string content);

        [OperationContract]
        void UpdateNote(int id, string title, string content);

        [OperationContract]
        void DeleteNote(int id);
    }
}
