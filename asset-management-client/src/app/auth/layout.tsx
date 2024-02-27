export const metadata = {
    title: 'Login Page',
    description: 'Auth Page',
}

import Link from "next/link"
import Header from "../../components/Header/header"
import Footer from "../../components/Footer/footer"

export default function AuthLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div className="h-dvh">
            <Header />
            <div className="flex justify-center items-center my-20">
                <div
                    className="login-items-container
                                bg-[url('/loginIMG/utilittiesAssetsManagement0102.jpg')] 
                                bg-cover bg-center bg-fixed w-full flex 
                                justify-center items-center "
                                >
                    {children}
                </div>
            </div>
            <Footer />
        </div>

    )
}
