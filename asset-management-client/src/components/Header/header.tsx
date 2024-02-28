"use client"
import { tokenRefresh } from "@/api/auth/tokenRefresh";
import Image from "next/image";
import Link from "next/link";
import { useEffect, useRef, useState } from "react";


const Header = () => {
  const [accountName, setAccountName] = useState("");
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [accountToken, setAccountToken] = useState(() => {
    if (typeof window !== 'undefined') {
      return localStorage.getItem('Account');
    }
  });
  const isMounted = useRef(false);
  async function getAccountName(_accountToken: string | null = null) {
    if (_accountToken != null) {
      const accountData = JSON.parse(_accountToken);
      const tokenExpirTime = accountData.tokenExpirTime;
      const currentTime = Date.now() / 100000;
      if (currentTime - tokenExpirTime / 100000 >= 0.1) {
        await tokenRefresh(_accountToken);
      }
      //make string first letter uppercase
      const name = accountData.userName.charAt(0).toUpperCase() + accountData.userName.slice(1);
      setAccountName("Welcome " + name);
      setIsLoggedIn(true);
    }
  }
  // Check user login or not, if login set account name
  useEffect(() => {
    accountToken ? getAccountName(accountToken) : getAccountName();
    if (isMounted.current) {
      tokenRefresh(accountToken || '');
    }
    // console.log(new Date().getTime() / 1000)
  }, [accountToken])

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
      <div className="flex items-center justify-end w-1/2">
        {isLoggedIn ? (
          <div className="text-white text-l lg:text-l font-bold justify-start">
            {accountName}
          </div>
        ) : (
          <Link href="/auth/login">
            <div className="text-white text-l lg:text-l font-bold justify-start">
              {accountName ? accountName : 'Login'}
            </div>
          </Link>
        )}
      </div>
    </header>
  );
};

export default Header;