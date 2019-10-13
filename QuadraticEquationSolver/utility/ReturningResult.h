#pragma once
#include <string>

// inspired by Alexandrescu's Expected<T>, but I want to work with partly successful result
template<class TResult>
struct Result
{
   TResult value;
   std::string error;
};
