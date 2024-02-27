'use client';
import { useState } from 'react'
import { useRouter } from 'next/navigation'
import { registfunc } from '@/api/auth/regist';

export default function LoginForm() {
  // const [firstname, setFirstname] = useState(""); // [state, setState
  // const [lastname, setLastname] = useState(""); // [state, setState
  // const [email, setEmail] = useState("");
  // const [password, setPassword] = useState("");
  // const [passwordConfirmation, setPasswordConfirmation] = useState(""); // [state, setState
  const router = useRouter();

  const registSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const registData = new FormData(e.currentTarget);
    try {
      if (await registfunc(registData) === 201) {
        console.log('Registration successful');
        // router.push('/dashboard');
      }
    } catch (error) {
      console.log("fail to register user")
    }
  };

  return (
    <div className="block items-center justify-center">

      <p className="text-base font-bold pb-3 text-[#4F5864] text-center">Sign up with your email</p>
      <form onSubmit={registSubmit} className='max-w-md'>
        <input
          type="text"
          name="userName"
          placeholder='User Name'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
        />

        {/* <input
          type="text"
          name='lastName'
          placeholder='last Name'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
        /> */}

        <input
          type="text"
          name='email'
          placeholder='Email Address'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
        />
        <input
          type="text"
          name='password'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
          placeholder='Password'
        />

        <input
          type="text"
          name='confirmPassword'
          // className="text-black block mb-4 py-2 pr-60"
          className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
          placeholder='Confirm Password'
        />
        <button type="submit" className="bg-[#1EB3EC] rounded-full border-4 w-full px-32 py-1 text-white text-center">Regist</button>
      </form>
    </div>
  )
}