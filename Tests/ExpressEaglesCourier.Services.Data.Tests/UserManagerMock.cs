namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Moq;

    // public class UserManagerMock
    // {
    //    public static Mock<UserManager<ApplicationUser>> MockUserManager(List<ApplicationUser> userList)
    //    //where TApplicationUser : class
    //    {
    //        var store = new Mock<IUserStore<ApplicationUser>>();
    //        var mgr = new Mock<UserManager<ApplicationUser>>(store.Object,
    //            null, null, null, null, null, null, null);
    //        mgr.Object.UserValidators.Add(new UserValidator<ApplicationUser>());
    //        mgr.Object.PasswordValidators.Add(new PasswordValidator<ApplicationUser>());

    // mgr.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
    // mgr.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<ApplicationUser, string>((x, y) => userList.Add(x));
    //        mgr.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

    // return mgr;
    // }
    // }
}
