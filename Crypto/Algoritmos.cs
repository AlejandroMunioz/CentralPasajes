namespace Crypto
{
    public class Encriptador {
        ISecurityElement _algoritmo1;
        ISecurityElement _algoritmo2;
        ISecurityElement _algoritmo3;
        public Encriptador(ISecurityElement algoritmo1, ISecurityElement algoritmo2, ISecurityElement algoritmo3) {
            _algoritmo1 = algoritmo1;
            _algoritmo2 = algoritmo2;
            _algoritmo3 = algoritmo3;
        }

        public string Encrypt(string text)
        {
            return _algoritmo3.Encrypt(_algoritmo2.Encrypt(_algoritmo1.Encrypt(text)));
        }
        public string Decrypt(string text) {
            return _algoritmo1.Decrypt(_algoritmo2.Decrypt(_algoritmo3.Decrypt(text)));
            
        }
    }
    public class Algoritmo1 : ISecurityElement {
        public  string StringReverse(string texto)
        {
            char[] charArray = texto.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public  string Encrypt(string text)
        {
            return StringReverse(text);
        }
        public  string Decrypt(string text)
        {
            return StringReverse(text);
        }
    }
    public class Algoritmo2 : ISecurityElement {
        public Func<int, int> FuncEncrypt { get; set; }
        public Func<int, int> FuncDencrypt { get; set; }
        public Algoritmo2(Func<int, int> funcEncrypt, Func<int, int> funcDencrypt) {
            this.FuncEncrypt = funcEncrypt;
            this.FuncDencrypt = funcDencrypt;
        }
        public string Encrypt(string text) {
            var result = new char[text.Length];
            for (int i = 0; i < text.Length; i++) {
                result[i] = (char)FuncEncrypt(Convert.ToInt32(text[i]));
            }
            return new string(result);
        }
        public string Decrypt(string text) {
            var result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                result[i] = (char)FuncDencrypt(Convert.ToInt32(text[i]));
            }
            return new string(result);
        }
    }
    public class Algoritmo3 : ISecurityElement {
    
        public  string Encrypt(string text)
        {
            

            return changeEncrypt(text, 0, text.Length - 1);
        }
        public  string Decrypt(string text)
        {
            return changeDecrypt(text, 0 , text.Length - 1);
        }
        public  string changeEncrypt(string text, int start, int end) { 
          if(start == end) return text;
           var result = text.ToCharArray();
           result[start] = Convert.ToInt32(text[start]) == 65535 ? text[start]  : (char)Convert.ToInt32(text[start] +1);
         return changeEncrypt(string.Join("",result.Select(x=>x.ToString())), start+1, end);
            
        }
        public  string changeDecrypt(string text, int start, int end)
        {
            if (start == end) return text;
            if (start == end) return text;
            var result = text.ToCharArray();
            result[start] = Convert.ToInt32(text[start]) == 65535 ? text[start] : (char)Convert.ToInt32(text[start] - 1);
            return changeDecrypt(string.Join("", result.Select(x => x.ToString())), start + 1, end);

        }
    }
    public interface ISecurityElement
    {
        string Encrypt(string text) ;
        string Decrypt(string text);
    }

    //https://stackoverflow.com/questions/5348844/how-to-convert-a-string-to-ascii

}
