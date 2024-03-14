import VerticalNavBar from "@/components/NavBar"

export const metadata = {
    title: 'About Us',
    description: 'About Us Page',
}

export default function AboutLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div className="flex flex-row w-full">
            <div className="basis-1/8 bg-[#09A94E]">
                {/* <div className="max-w-xs bg-[#09A94E]"> */}
                <div className="px-4 pt-10">
                    <VerticalNavBar />
                </div>
            </div>
            {/* <div className="col-span-5 pt-4"> */}
            <div className="basis-7/8 justify-center w-full">
                <div className="px-4">
                    {children}
                </div>
            </div>
        </div>

    )
}
