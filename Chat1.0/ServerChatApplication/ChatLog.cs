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
    
    public partial class ChatLog
    {
        public int ChatLog_Id { get; set; }
        public int Message_Id { get; set; }
        public int Chat_Id { get; set; }
    
        public virtual ChatRoom ChatRoom { get; set; }
        public virtual Message Message { get; set; }
    }
}
