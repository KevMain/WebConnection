using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace CCE.WebConnection.Tests
{
    public class ContextMocks
    {
        public Mock<HttpContextBase> HttpContext { get; private set; }
        public Mock<HttpRequestBase> Request { get; private set; }
        public Mock<HttpResponseBase> Response { get; private set; }
        public RouteData RouteData { get; private set; }

        public ContextMocks(Controller onController)
        {
            HttpContext = new Mock<HttpContextBase>();
            Request = new Mock<HttpRequestBase>();
            Response = new Mock<HttpResponseBase>();
            HttpContext.Setup(x => x.Request).Returns(Request.Object);
            HttpContext.Setup(x => x.Response).Returns(Response.Object);
            HttpContext.Setup(x => x.Session).Returns(new FakeSessionState());
            Request.Setup(x => x.Cookies).Returns(new HttpCookieCollection());
            Response.Setup(x => x.Cookies).Returns(new HttpCookieCollection());
            Request.Setup(x => x.QueryString).Returns(new NameValueCollection());
            Request.Setup(x => x.Form).Returns(new NameValueCollection());

            RequestContext rc = new RequestContext(HttpContext.Object, new RouteData());
            onController.ControllerContext = new ControllerContext(rc, onController);
        }

        public void SetupContextUser(string userName)
        {
            HttpContext.Setup(x => x.User).Returns(new FakePrincipal(new FakeIdentity(userName)));
        }

        private class FakeSessionState : HttpSessionStateBase
        {
            Dictionary<string, object> items = new Dictionary<string, object>();

            public override object this[string name]
            {
                get { return items.ContainsKey(name) ? items[name] : null; }
                set { items[name] = value; }
            }
        }

        private class FakePrincipal : IPrincipal
        {
            private FakeIdentity _ident;
            public FakePrincipal(FakeIdentity ident)
            {
                _ident = ident;
            }

            public IIdentity Identity
            {
                get { return _ident; }
            }

            public bool IsInRole(string role)
            {
                throw new NotImplementedException();
            }
        }

        private class FakeIdentity : IIdentity
        {
            private string _name;
            public FakeIdentity(string Name)
            {
                _name = Name;
            }

            public string AuthenticationType
            {
                get { throw new NotImplementedException(); }
            }

            public bool IsAuthenticated
            {
                get { throw new NotImplementedException(); }
            }

            public string Name
            {
                get { return _name; }
            }
        }
    }
}
