"use client"
import Image from "next/image";
import AccountComponent from "./account";
import React from "react";


const Header = () => {
  return (
    <header className="bg-[#09A94E] px-4 flex flex-row items-center">
      <div className="flex basis-2/3 items-center">
        <a href="/" className="flex items-center">
          <Image className="w-20 mx-4"
            width={500}
            height={500}
            src="/logo.png"
            alt="logo" />
          <h1 className="text-white text-l lg:text-2xl font-bold">Asset Management System</h1>
        </a>
      </div>
      <div className="flex basis-1/3 flex-row-reverse items-center">
        <AccountComponent />
      </div>
    </header>
  );
};

export default Header;