using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Note
    {
        /// <summary>
        ///  게시물 번호
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물제목
        /// </summary>
        [Required]
        public string NoteTitle { get; set; }
        /// <summary>
        /// 게시물내용
        /// </summary>
        [Required]
        public string NoteContents { get; set; }
        /// <summary>
        /// 작성자번호
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")] //외래키설정
        public virtual User User { get; set; }
    }
}