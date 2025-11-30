namespace BeyazEsya.Models
{
    public class CartHelper
    {
        public readonly IHttpContextAccessor _http;

        public CartHelper(IHttpContextAccessor http)
        {
            _http = http;
        }
        public string GetOrCreateCart()
        {
            var context=_http.HttpContext;
            var CardId = context.Request.Cookies["CardId"];
            if (CardId == null && string.IsNullOrEmpty(CardId))
            {
                CardId=Guid.NewGuid().ToString();
                context.Response.Cookies.Append("CartId", CardId, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(2)
                });
            }

            return CardId;
        }

    }
}
