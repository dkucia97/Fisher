using System;
using System.Text;

namespace Fisher.Core.Domain
{    //value object 
     public class Note:BaseEntity<int>
     {
         public string BaseWord{ get; set; }
         public string  ForeignWord { get; set; }
         public string Definition { get; set; }=String.Empty;

         public Note(string baseWord, string foreignWord)
         {
             BaseWord = baseWord;
             ForeignWord = foreignWord;
         }
         
         public Note(){}
     }
 }