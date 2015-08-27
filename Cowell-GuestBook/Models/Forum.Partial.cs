namespace Cowell_GuestBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ForumMetaData))]
    public partial class Forum
    {
    }
    
    public partial class ForumMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [Required]
        public string TITLE { get; set; }
        [Required]
        public System.DateTime BUD_DTM { get; set; }
    
        public virtual ICollection<ARTICLE> ARTICLE { get; set; }
    }
}
