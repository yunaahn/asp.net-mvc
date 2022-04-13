using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        /// <summary>
        ///  사용자 번호 (xml주석)
        /// </summary>
        [Key] //pk설정
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자이름
        /// </summary>

        //not null
        [Required(ErrorMessage = "사용자 이름 입력")]
        public string UserName { get; set; }
        /// <summary>
        /// 사용자 Id
        /// </summary>
        /// 
        [Required(ErrorMessage ="사용자 아이디 입력")]
        public string UserId { get; set; }

        /// <summary>
        /// 사용자비번
        /// </summary>
        [Required(ErrorMessage = "사용자 비번 입력")]
        public string UserPassword { get; set; }
    }
}
