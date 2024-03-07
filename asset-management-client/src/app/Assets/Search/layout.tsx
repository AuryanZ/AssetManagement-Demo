export const metadata = {
    title: 'Login Page',
    description: 'Login Page',
}

export default function AssetsSerachLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div>
            <section >
                {children}
            </section>
        </div>

    )
}