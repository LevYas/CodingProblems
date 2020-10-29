#pragma once
#include <sstream>

// wrapper for std::stringstream for making one-line string formatting
class sstr final
{
private:
   std::stringstream _ss;

public:
   sstr(const std::string &str = "")
      : _ss(str)
   {}

   template<typename T> sstr &operator<<(const T &t)
   {
      _ss << t;
      return *this;
   }

   operator std::string() const
   {
      return _ss.str();
   }
};
