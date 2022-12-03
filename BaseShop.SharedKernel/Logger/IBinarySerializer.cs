using System;
namespace BaseShop.SharedKernel.Logger;





public interface IBinarySerializer
{
  byte[] Serialize(object obj);
  object Deserialize(byte[] data, Type type);
  T Deserialize<T>(byte[] data) where T : class;
}

