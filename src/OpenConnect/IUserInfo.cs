using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect
{
    public interface IUserInfo
    {
        string Id { get; }

        string NickName { get; }

        string Email { get; }

        string Avatar { get; }

        Gender Gender { get; }
    }
}
