"use client"
import Image from "next/image";
import AccountComponent from "./account";


const Header = () => {
  return (
    <header className="bg-[#09A94E] px-4 flexitems-center flex">
      <div className="flex items-center  justify-start w-1/2">
        <a href="/" className="flex justify-center items-center">
          <Image className="w-20 mx-4"
            width={500}
            height={500}
            src="/logo.png"
            alt="logo" />
          <h1 className="text-white text-l lg:text-2xl font-bold">Asset Management System</h1>
        </a>
      </div>
      <AccountComponent />
    </header>
  );
};

export default Header;