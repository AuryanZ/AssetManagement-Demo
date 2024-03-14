import { logoutfunc } from "@/api/auth/logout";
import Link from "next/link";
import { useRef, useState, useEffect, useContext } from "react";
import { decodeToken, removeToken } from "../../../services/token/token";
import AuthContext from "@/events/eventContext";

const AccountComponent = () => {
    const isMounted = useRef(false);
    const [isOpened, setIsOpened] = useState(false);
    const [accountName, setAccountName] = useState("");
    const { isLoggedIn, login, logout } = useContext(AuthContext);

    // const router = useRouter();
    async function getAccountName() {
        try {
            const accountData = await decodeToken();
            if (accountData === null) {
                logout();
                setAccountName("");
                removeToken();
            }
            //make string first letter uppercase
            if (accountData && accountData.username) {
                const name = accountData.username.charAt(0).toUpperCase() + accountData.username.slice(1);
                setAccountName("Welcome " + name);
                login();
                // setIsLoggedIn(true);
            }
        } catch (error) {
            console.error("Failed to fetch data", error);
        }

    }

    // Check user login or not, if login set account name
    useEffect(() => {
        isMounted.current = true;
        const fetchData = async () => {
            if (isMounted.current) {
                await getAccountName();
            }
        };
        fetchData();

        return () => {
            isMounted.current = false;
        };
    }, [isLoggedIn]);


    return (
        <div className="h-full relative cursor-pointer select-none flex text-white text-l lg:text-l font-bold">
            <div className={`${isOpened ? "text-black bg-white p-2 mt-2  border-b-0 border-[#888888]" : "p-4"}`}>
                {/* <div className={AccountToggle(isOpened)}> */}
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
                            setAccountName("");
                            logout();
                            window.location.href = '/auth/login';
                        })
                    }>Logout</div>
                </div>

            </div>
        </div>
    );
}

export default AccountComponent;