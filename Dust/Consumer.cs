using Dust;

namespace Wiki.Machinery.Examples
{
    public class Consumer {
        private readonly ConsumerKey _consumerKey;
        private readonly string _secret;

        public Consumer(ConsumerKey consumerKey, string secret) {
            _consumerKey = consumerKey;
            _secret = secret;
        }

        public ConsumerKey ConsumerKey {
            get { return _consumerKey; }
        }

        public string Secret {
            get { return _secret; }
        }
    }
}