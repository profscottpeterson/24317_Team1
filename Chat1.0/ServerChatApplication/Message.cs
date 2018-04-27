//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerChatApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            this.ChatLogs = new HashSet<ChatLog>();
        }
    
        public int Message_Id { get; set; }
        public string UserName { get; set; }
        public int Chat_Id { get; set; }
        public System.DateTime Time_Sent { get; set; }
        public string Message_Body { get; set; }
        public System.DateTime Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatLog> ChatLogs { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
        public virtual User User { get; set; }
    }
}
