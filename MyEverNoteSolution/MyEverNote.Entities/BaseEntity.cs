using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.Entities
{
    public class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Primary key ve identity ayarı
        public int Id { get; set; } //id yi gördüğünde otomatik seçiyor. Başına ek bir şey yazarsan belirtmen gerek.
        [Required,DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedOn { get; set; }
        [Required, DisplayName("Güncelleme Tarihi")]
        public DateTime ModifiedOn { get; set; }
        [Required, DisplayName("Oluşturan Kullanıcı"),StringLength(30)]
        public string ModifiedUserName { get; set; }

    }
}
