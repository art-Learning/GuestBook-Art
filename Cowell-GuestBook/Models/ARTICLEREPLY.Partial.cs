namespace Cowell_GuestBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ARTICLEREPLYMetaData))]
    public partial class ARTICLEREPLY
    {
    }
    
    public partial class ARTICLEREPLYMetaData
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int ARTICLE_ID { get; set; }
        [Required]
        [DisplayName("回覆")]
        public string BODY { get; set; }
        [Required]
        [DisplayName("回覆時間")]
        public System.DateTime BUD_DTM { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        [DisplayName("發言人")]
        public string AUTHOR { get; set; }
    
        public virtual ARTICLE ARTICLE { get; set; }
    }
}
