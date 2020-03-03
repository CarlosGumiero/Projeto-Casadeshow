using System.Collections.Generic;

namespace Casadeshow.Hateoas
{
    public class Hateoas
    {
        private string url;
        private string protocol = "https://";
        public List<Link> actions = new List<Link>();

        public Hateoas(string url)
        {
            this.url = url;
        }

        public Hateoas(string url, string protocol)
        {
            this.url = url;
            this.protocol = protocol;
        }

        public void AddAction(string rel, string method)
        {
            // "https://localhost:5001/casadeshow/v1/Produtos"
            actions.Add(new Link(this.protocol + this.url, rel, method));
        }

        public Link[] GetActions(string sufix)
        {
            Link[] tempLinks = new Link[actions.Count];

            for(int i = 0; i < tempLinks.Length; i++)
            {
                tempLinks[i] = new Link(actions[i].href, actions[i].rel, actions[i].method);
            }

            foreach(var link in tempLinks)
            {
                // "https://localhost:5001/casadeshow/v1/Produtos/sufixes"
                link.href = link.href+"/"+sufix.ToString();
            }
            return tempLinks;
        }
    }
}