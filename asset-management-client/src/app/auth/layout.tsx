export const metadata = {
    title: 'Login Page',
    description: 'Auth Page',
}

export default function AuthLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div className="flex items-center my-20">
            <div
                className="login-items-container bg-cover bg-center w-full 
                                bg-[url('/loginIMG/utilittiesAssetsManagement0102.jpg')]"
            >
                {children}
            </div>
        </div>

    )
}
