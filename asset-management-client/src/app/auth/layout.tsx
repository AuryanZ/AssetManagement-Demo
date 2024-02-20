export const metadata = {
    title: 'Login Page',
    description: 'Auth Page',
}

import Link from "next/link"
import Header from "../../../components/Header/header"
import Footer from "../../../components/Footer/footer"

export default function AuthLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div className="">
            <Header />
                <div
                    className="mx-auto my-5 center 
                bg-[url('/loginIMG/utilittiesAssetsManagement0102.jpg')] 
                bg-cover bg-center h-full w-full flex 
                justify-center items-center"
                >

                    {children}
                </div>
            <Footer />
        </div>

    )
}
