"use client"
import VerticalNavBar from "@/components/NavBar"

export default function app() {
    return (

        // <div className="grid grid-cols-6 gap-4" >
        <div className="flex flex-row justify-center ">
            <div className="basis-1/8 bg-[#09A94E]">
                {/* <div className="max-w-xs bg-[#09A94E]"> */}
                <div className="px-4 pt-10">
                    <VerticalNavBar />
                </div>
            </div>
            {/* <div className="col-span-5 pt-4"> */}
            <div className="basis-7/8 w-full">
                <div className="px-4">
                    home
                </div>
            </div>
        </div>
    )

}