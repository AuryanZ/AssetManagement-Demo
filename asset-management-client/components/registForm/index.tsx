'use client';
import { useState } from 'react'
import { useRouter } from 'next/navigation'
import styles from "./loginForm.module.css"

export default function LoginForm() {
  const [firstname, setFirstname] = useState(""); // [state, setState
  const [lastname, setLastname] = useState(""); // [state, setState
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordConfirmation, setPasswordConfirmation] = useState(""); // [state, setState
  const [termsNconditions, setTermsNconditions] = useState(false); // [state, setState
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    // TODO: Implement authentication logic here
    router.push("/");
  };

  return (
    <div className="block items-center justify-center">
      <p className="text-2l font-bold pb-3 text-[#4F5864] text-center">Create a xxx acount with ...</p>

      <div className="signinreg-divider flex text-base items-center px-4 my-4">
        <div className="flex-1 h-px bg-gray-300 mr-4"></div>
        <span className="text-black">or</span>
        <div className="flex-1 h-px bg-gray-300 ml-4"></div>
      </div>

      <p className="text-base font-bold pb-3 text-[#4F5864] text-center">Sign up with your email</p>
      <form onSubmit={handleSubmit} className='max-w-md'>
        <input
          type="text"
          value={firstname}
          onChange={(event) => setFirstname(event.target.value)}
          placeholder='First Name'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
        />

        <input
          type="text"
          value={lastname}
          onChange={(event) => setLastname(event.target.value)}
          placeholder='last Name'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
        />

        <input
          type="text"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
          placeholder='Email Address'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
        />
        <input
          type="text"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
          placeholder='Password'
        />

        <input
          type="text"
          value={passwordConfirmation}
          onChange={(event) => setPasswordConfirmation(event.target.value)}
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
          placeholder='Confirm Password'
        />

        <div className="block items-center mb-8">
          <div className="flex items-center mb-8">
            <input
              type="checkbox"
              checked={termsNconditions}
              onChange={(event) => setTermsNconditions(event.target.checked)}
              className="mr-2"
            />
            <label htmlFor="termsNconditions" className="text-sm text-gray-600">
              Yes, I would like to receive emails with awesome xxx deals.
            </label>
          </div>
          <div className="block items-center mb-8 text-[#4F5864] text-sm text-center ">
            {/* <p className="text-sm text-[#4F5864] text-center break-words"> */}
            By registering I accept the website
            <a className="text-sm text-center text-[#01b2ee] underline" href="/"> terms & conditions </a>
            and
            <a className="text-sm text-center text-[#01b2ee] underline" href="/"> privacy policy </a>
            {/* </p> */}
          </div>
        </div>

        <button type="submit" className="bg-[#1EB3EC] rounded-full border-4 w-full px-32 py-1 text-white text-center">Regist</button>
      </form>

      <p className="text-2l pb-3 mt-4 text-[#4F5864] text-center">Already have a xxx account?
        <a className="text-base text-left text-[#01b2ee]" href="login"> Sign in</a>
      </p>
    </div>
  )
}