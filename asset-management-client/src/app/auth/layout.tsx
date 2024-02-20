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
        <div className="text-[#1EB8EA] ">
            <Header />
            <div className="mx-auto w-full my-5 center ">
                {children}
            </div>
            <Footer />
        </div>

    )
}
