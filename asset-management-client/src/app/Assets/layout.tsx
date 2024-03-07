export const metadata = {
    title: 'Login Page',
    description: 'Auth Page',
}

export default function AssetsLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div>
            {children}
        </div>

    )
}
