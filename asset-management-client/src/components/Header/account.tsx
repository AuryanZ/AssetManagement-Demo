import { logoutfunc } from "@/api/auth/logout";
import { tokenRefresh } from "@/api/auth/tokenRefresh";
import Link from "next/link";
import { useRef, useState, useEffect } from "react";

const AccountComponent = () => {
    const isMounted = useRef(false);
    const [isOpened, setIsOpened] = useState(false);
    const [accountName, setAccountName] = useState("");
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [accountToken, setAccountToken] = useState(() => {
        if (typeof window !== 'undefined') {
            return localStorage.getItem('Account');
        }
    });
    // const router = useRouter();
    async function getAccountName(_accountToken: string | null = null) {
        if (_accountToken != null) {
            const accountData = await JSON.parse(_accountToken);
            //make string first letter uppercase
            if (accountData.userName) {
                const name = accountData.userName.charAt(0).toUpperCase() + accountData.userName.slice(1);
                setAccountName("Welcome " + name);
                setIsLoggedIn(true);
            }
        }
    }
    // Check user login or not, if login set account name
    useEffect(() => {

        isMounted.current = true;
        const fetchData = async () => {
            if (isMounted.current) {
                await tokenRefresh().then(async (res) => {
                    if (res != null) {
                        setAccountToken(JSON.stringify(res));
                        getAccountName(JSON.stringify(res));
                        accountToken ? getAccountName(accountToken) : getAccountName();
                    } else {
                        await localStorage.removeItem('Account');
                        setAccountToken(null);
                        setAccountName("");
                        setIsLoggedIn(false);
                    }
                }).catch((error) => {
                    console.log(error);
                });
                // isMounted.current = true;
            }
        };
        fetchData();

        return () => {
            isMounted.current = false;
        };
    }, [])


    return (
        <div className="h-full relative cursor-pointer select-none flex justify-end w-1/2 text-white text-l lg:text-l font-bold">
            <div className="p-4">
                {isLoggedIn ? (
                    <div
                        className="relative"
                        // className="text-white text-l lg:text-l font-bold justify-start"
                        onClick={() => {
                            return setIsOpened(!isOpened);
                        }}>
                        {accountName}
                    </div>
                ) : (
                    <Link href="/auth/login">
                        {/* <div className="text-white text-l lg:text-l font-bold justify-start"> */}
                        <div className="relative">
                            {accountName ? accountName : 'Login'}
                        </div>
                    </Link>
                )}
            </div>
            <div
                //  ref={isOpened}
                className={`w-[calc(10vw-2rem)] 
                lg:w-[calc(10vw-6rem)]  absolute 
                top-full  bg-white border 
                border-[#888888]  ${isOpened ? "block" : "hidden"}`}>

                <div className="flex flex-col mx-2 text-black">
                    <Link href="/">Profile</Link>
                    <div onClick={() => 
                        logoutfunc().then(() => {
                            setIsLoggedIn(false);
                            setAccountToken(null);
                            setAccountName("");
                            window.location.href = '/auth/login';
                        })
                    }>Logout</div>
                </div>

            </div>
        </div>
    );
}

export default AccountComponent;