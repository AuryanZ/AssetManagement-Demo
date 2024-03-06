import { logoutfunc } from "@/api/auth/logout";
import { tokenRefresh } from "@/api/auth/tokenRefresh";
import Link from "next/link";
import { decode } from "punycode";
import { useRef, useState, useEffect } from "react";
import { decodeToken } from "../../../services/token/token";
import { get } from "http";

const AccountComponent = () => {
    const isMounted = useRef(false);
    const [isOpened, setIsOpened] = useState(false);
    const [accountName, setAccountName] = useState("");
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    // const router = useRouter();
    async function getAccountName() {
        try {
            const accountData = await decodeToken();
            //make string first letter uppercase
            if (accountData && accountData.username) {
                const name = accountData.username.charAt(0).toUpperCase() + accountData.username.slice(1);
                setAccountName("Welcome " + name);
                setIsLoggedIn(true);
            }
        } catch (error) {
            console.error("Failed to fetch data", error);
        }

    }

    const AccountToggle = (isOpened: boolean) => {
        return isOpened ? "text-black bg-white p-2 mt-2 border border-b-0 border - [#888888]" : "p-4";
    };

    // Check user login or not, if login set account name
    useEffect(() => {
        isMounted.current = true;
        const fetchData = async () => {
            if (isMounted.current) {
                getAccountName();
            }
        };
        fetchData();

        return () => {
            isMounted.current = false;
        };
    }, [])


    return (
        <div className="h-full relative cursor-pointer select-none flex text-white text-l lg:text-l font-bold">
            <div className={AccountToggle(isOpened)}>
                {isLoggedIn ? (
                    <div
                        className="account-toggle relative"
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
                className={`absolute top-full  bg-white border border-t-0
                border-[#888888]  ${isOpened ? "block" : "hidden"}`}>

                <div className="flex flex-col mx-2 text-black">
                    <Link href="/dashboard/admin">Profile</Link>
                    <div onClick={() =>
                        logoutfunc().then(() => {
                            setIsLoggedIn(false);
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