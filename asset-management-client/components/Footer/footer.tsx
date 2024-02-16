// footer
import React from 'react';

const Footer = () => {
    const year = new Date().getFullYear();
    return (
        <footer className='bg-[#f8f9fa] px-4 p-10 bottom-0 w-full'>
            <p className='text-center'>© {year} Rui Zeng</p>
        </footer>
    );
}


export default Footer;