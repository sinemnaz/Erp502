﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.Entities
{
    [Table("Notes")]
    public class Note:BaseEntity
    {
        [StringLength(60),Required, DisplayName("Başlık")]
        public string Title { get; set; }
        [StringLength(3000), DisplayName("Metin")]
        public string Text { get; set; }
        [DisplayName("Taslak mı?")]
        public bool IsDraft { get; set; }//taslak mı değil mi diye soruyor. Bool kullanılıyor o yüzden
        [DisplayName("Beğeni Sayısı")]
        public int LikeCount { get; set; }


        public virtual EverNoteUser Owner { get; set; } //bir notun bir sahibi olur. 
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }

        public Note()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();
        }
        
    }
}
