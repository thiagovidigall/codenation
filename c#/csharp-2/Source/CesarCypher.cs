using System;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {
            
            if (message == null)
                throw new System.ArgumentNullException();

            try
            {

                if (message.Equals(string.Empty))
                    return string.Empty;
                else
                {
                    string msgCifrada = CryptDecryptMessage(message.ToLower());
                    if (msgCifrada == null)
                        throw new System.ArgumentOutOfRangeException();

                    return msgCifrada;
                }
                
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null)
                throw new System.ArgumentNullException();

            try
            {

                if (cryptedMessage.Equals(string.Empty))
                    return string.Empty;
                else
                {
                    string msgCifrada = CryptDecryptMessage(cryptedMessage.ToLower(),true);
                    if (msgCifrada == null)
                        throw new System.ArgumentOutOfRangeException();

                    return msgCifrada;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool VerificarCaracteresEspeciais(char elemento)
        {
            string permitido = "abcdefghijklmnopqrstuvwxyz0123456789 ";
            //for (int i = 0; i < message.Length; i++)
            //{
            //    if (!permitido.Contains(message.ElementAt(i)))
            //        return false;
            //}
            //return true;

            return permitido.Contains(elemento);
        }

        private string CryptDecryptMessage(string message, bool decrypt = false)
        {
            int valorDaPosicao = 0;
            StringBuilder msgCifrada = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {

                if (!VerificarCaracteresEspeciais(message.ElementAt(i)))
                    return null;

                //elemento tipo char convertido para valor decimal da tabela ASCII
                valorDaPosicao = message.ElementAt(i);

                //Não decifra os espaços(32) e números(48-57)
                if (valorDaPosicao != 32 && !(valorDaPosicao >= 48 && valorDaPosicao <= 57))
                {
                    //avançar ou voltar 3 casas
                    if (!decrypt)
                    {
                        switch (valorDaPosicao)
                        {
                            case 120:
                                valorDaPosicao = 97;
                                break;
                            case 121:
                                valorDaPosicao = 98;
                                break;
                            case 122:
                                valorDaPosicao = 99;
                                break;
                            default:
                                valorDaPosicao += 3;
                                break;
                        }
                    }
                    else
                    {
                        switch (valorDaPosicao)
                        {
                            case 97:
                                valorDaPosicao = 120;
                                break;
                            case 98:
                                valorDaPosicao = 121;
                                break;
                            case 99:
                                valorDaPosicao = 122;
                                break;
                            default:
                                valorDaPosicao -= 3;
                                break;
                        }
                    }
                }                    

                msgCifrada.Append(char.ConvertFromUtf32(valorDaPosicao));
            }

            return msgCifrada.ToString();
        }
    }
}
