"use client"
import Image from "next/image";
import { useEffect, useState } from "react";


const Header = () => {
  const [accountName, setAccountName] = useState("Login");

  // Check user login or not, if login set account name
  // useEffect(() => {
  //   const isLoggedIn = checkUserlogin();
  //   if (isLoggedIn) {
  //     setAccountName(getAccountName());
  //   }
  // })

  return (
    <header className="bg-[#09A94E] px-4 flexitems-center flex">
      <div className="flex items-center  justify-start w-1/2">
        <a href="" className="flex justify-center items-center">
          <Image className="w-20 mx-4"
            width={500}
            height={500}
            src="/logo.png"
            alt="logo" />
          <h1 className="text-white text-l lg:text-2xl font-bold">Asset Management System</h1>
        </a>
      </div>
      <div className="flex items-center justify-end w-1/2">
        <div className="text-white text-l lg:text-l font-bold justify-start">{accountName ? accountName : 'Login'}</div>
      </div>
    </header>
  );
};

export default Header;