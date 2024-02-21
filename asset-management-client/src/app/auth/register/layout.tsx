// import styles from "./layout.module.css"
import Link from "next/link"

export const metadata = {
  title: 'Sign Up Page',
  description: 'Sign Up Page',
}

export default function RegisterLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <div className="display: flex flex-col items-center my-10">
      <div className="max-w-lg">
        <section className="items-center flex-wrap bg-[#ffffff] rounded-t-lg shadow-lg py-10 opacity-95">

          <a className="text-lg px-5 py-4 border-[1px]
            border-[#D6DCE0] border-t-0 border-l-0 border-r-0 mb-[-2px]"></a>


          <a className="text-lg text-center justify-center w-1/2 px-[1.6rem] py-4 border-[1px]
                 border-[#D6DCE0] border-t-0 border-l-0 border-r-0 mb-[-2px]" href="login">Already Registered?</a>

          <a className="text-lg text-center justify-center w-1/2 rounded-tl-lg rounded-tr-lg px-[2.4rem] 
                py-4 border-[1px] border-[#D6DCE0] border-b-0 mb-[-2px]" href="register" >New to Here?</a>


          <a className="text-lg px-5 py-4 border-[1px]
            border-[#D6DCE0] border-t-0 border-l-0 border-r-0 mb-[-2px] pr-9"></a>
        </section>
        <section className="items-center bg-[#ffffff] rounded-b-lg shadow-lg p-6 max-w-lg opacity-95">
          {children}
        </section>
      </div>
    </div>

  )
}